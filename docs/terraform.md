# Terraform

## What it does
This Terraform configuration prepares the local Kubernetes infrastructure needed before deploying the Locatic app on minikube.

It creates:
- the `locatic` namespace
- a PersistentVolume used later by the SQLite PersistentVolumeClaim

It does not deploy the application itself. That part is handled by the Kubernetes manifests in the `k8s/` folder.

## Requirements
- minikube running (`minikube start`)
- kubectl configured on the `minikube` context
- Terraform installed locally

## Files
- `main.tf`: provider config, namespace and PersistentVolume resources
- `variables.tf`: configurable values (namespace name, storage size, host path)
- `outputs.tf`: values reused by the next steps (namespace, PV name)
- `.gitignore`: excludes `.terraform/`, `.terraform.lock.hcl` and `*.tfstate` files

## Variables
| Name | Description | Default |
| --- | --- | --- |
| kube_config_path | Path to the kubeconfig file | ~/.kube/config |
| kube_context | Kubernetes context used | minikube |
| namespace | Namespace created for the app | locatic |
| sqlite_storage_size | Size of the SQLite volume | 1Gi |
| sqlite_host_path | Path on the minikube node for the volume | /data/locatic-sqlite |

## Before running
The host path used by the PersistentVolume must exist inside the minikube VM:
```bash
minikube ssh -- sudo mkdir -p /data/locatic-sqlite
```

## Usage
```bash
cd infra/terraform
terraform init
terraform fmt
terraform validate
terraform plan
terraform apply
```
Terraform asks for explicit confirmation (`yes`) before applying any change.

## Outputs
```bash
terraform output
```
Gives the namespace name and the PV name, used afterwards to deploy the Kubernetes resources.

## State
The `terraform.tfstate` file is never committed (excluded via `.gitignore`), as required. This means the local state can be lost independently of the actual cluster (switching machines, accidentally deleting the `.terraform/` folder, etc.).

**Issue encountered**: after losing the local state file while the namespace and PersistentVolume still existed on the cluster, `terraform apply` failed with `already exists` errors. The resources were reattached to Terraform's state using:
```bash
terraform import kubernetes_namespace.locatic locatic
terraform import kubernetes_persistent_volume.sqlite_pv locatic-sqlite-pv
```
A `terraform plan` run afterwards confirmed `No changes`, meaning the state now matches the real infrastructure.

## Known limitations
- The Terraform state is local and not versioned, so it isn't shared between team members — each person needs to `init` and `apply` this configuration on their own machine.
- No remote backend (S3, Terraform Cloud, etc.) is used, consistent with the project constraint of not using any remote server.