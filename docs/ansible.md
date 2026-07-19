# Ansible Documentation

## Role of Ansible

Ansible is used to automate the local deployment process of the Locatic application.

The Ansible playbook simplifies deployment by executing Kubernetes commands automatically.

## Playbook Location

The Ansible files are located in:

```text
infra/ansible/
```


The directory contains:

- `inventory.ini`
- `deploy.yml`

## Inventory Configuration

The inventory file defines the target machines used by Ansible.

For this project, the deployment is executed locally using localhost.

## Playbook Workflow

The Ansible playbook performs the following steps:

1. Check the Kubernetes environment.
2. Verify Minikube availability.
3. Apply Kubernetes manifests.
4. Deploy the Locatic application.
5. Deploy the Nginx reverse proxy.
6. Install monitoring components.

## Kubernetes Deployment

Ansible applies Kubernetes resources from:

```text
k8s/
```

The deployed resources include:

- Application Deployment
- Services
- ConfigMaps
- Persistent Volume Claims
- Nginx reverse proxy configuration

## Terraform Dependency

Terraform is responsible for preparing the infrastructure environment.

Ansible uses this environment to automate the application deployment phase.

## Execute the Playbook

Run the following command:

```bash
ansible-playbook -i infra/ansible/inventory.ini infra/ansible/deploy.yml
```