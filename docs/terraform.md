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