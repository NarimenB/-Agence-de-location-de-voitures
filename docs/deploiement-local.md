# Local Deployment Guide

## Prerequisites
Make sure the following tools are installed on your machine:
- Docker Desktop (running)
- minikube
- kubectl
- Terraform
- Ansible

## Step 1 — Start minikube
```bash
minikube start --driver=docker
minikube ssh -- sudo mkdir -p /data/locatic-sqlite
```

## Step 2 — Apply Terraform infrastructure
```bash
cd infra/terraform
terraform init
terraform plan
terraform apply
terraform output
cd ../..
```
This creates the locatic namespace and the persistent volume for SQLite.

## Step 3 — Deploy to Kubernetes
```bash
kubectl apply -f k8s/
kubectl get all -n locatic
kubectl get pvc -n locatic
```
Wait for the pod to reach Running status.

## Step 4 — Run Ansible playbook
```bash
cd ansible
ansible-playbook playbook.yml
```
This sets up Nginx and the monitoring stack.

## Step 5 — Access the application
The application is accessible through Nginx. To verify locally:
```bash
kubectl port-forward service/locatic-app -n locatic 8080:80
```
Open http://localhost:8080

## Step 6 — Access monitoring
```bash
kubectl port-forward service/prometheus -n locatic 9090:9090
kubectl port-forward service/grafana -n locatic 3000:3000
```
- Prometheus: http://localhost:9090
- Grafana: http://localhost:3000