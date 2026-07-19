# Architecture

## Overview
Locatic follows a DevOps pipeline from source code to deployment on a local Kubernetes cluster.

## Flow
1. Developer pushes code to a feature branch
2. Pull Request is opened against main
3. GitHub Actions runs CI checks
4. After approval and merge, Docker image is built and pushed to ghcr.io
5. Local deployment is triggered with Terraform then Ansible
6. Application runs on minikube behind Nginx

## Components

### GitHub
- Stores the source code
- Manages Pull Requests and branch protection rules
- Triggers the CI/CD pipeline via GitHub Actions

### GitHub Actions
- Builds and tests the application on every Pull Request
- Builds and publishes the Docker image to ghcr.io on merge to main
- Does not deploy to minikube (minikube runs locally)

### Docker
- Multi-stage Dockerfile based on dotnet/sdk:8.0 for build and dotnet/aspnet:8.0 for runtime
- SQLite database stored in a volume mounted at /app/data
- Image published to ghcr.io/narimenb/locatic:latest
- Health check endpoint available at /health

### Terraform
- Prepares the local Kubernetes infrastructure on minikube
- Creates the locatic namespace
- Creates the persistent volume for SQLite at /data/locatic-sqlite

### Ansible
- Orchestrates the local deployment from the developer machine
- Verifies prerequisites
- Applies Kubernetes manifests
- Sets up Nginx, the application, and the monitoring stack

### Kubernetes
- Runs the application container
- Manages Nginx as the main entry point
- Handles persistent storage for SQLite via PVC
- Runs liveness and readiness probes on /health

### Nginx
- Acts as the reverse proxy and main entry point for users
- The application is not exposed directly

### SQLite
- Used as the application database
- Stored on a persistent volume so data survives pod restarts

### Prometheus and Grafana
- Prometheus collects metrics from all services
- Grafana displays dashboards for each service
- Each important service has at least one visible indicator