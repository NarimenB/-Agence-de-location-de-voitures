# Locatic — Car Rental Agency

## Overview
Locatic is an ASP.NET Core MVC web application for managing a car rental agency: brands, car models, cars, customers and bookings. This repository contains both the application code and the complete DevOps infrastructure.

## Project Structure
```
├── .github/workflows/    # GitHub Actions CI/CD pipeline
├── docs/                 # Project documentation
├── infra/terraform/      # Terraform configuration
├── k8s/                  # Kubernetes manifests
├── ansible/              # Ansible playbooks
├── Controllers/          # MVC Controllers
├── Models/               # Domain entities
├── Services/             # Business logic layer
├── Services/Interfaces/  # Service interfaces
├── Views/                # Razor views
├── Data/                 # DbContext and migrations
├── Dockerfile            # Docker image definition
└── README.md
```

## Prerequisites
- .NET 8 SDK
- Docker Desktop
- minikube
- kubectl
- Terraform
- Ansible

## Quick Start

### Run locally
```bash
dotnet restore
dotnet run
```
Open http://localhost:5207

### Run with Docker
```bash
docker build -t locatic:latest .
docker run -p 8080:8080 locatic:latest
```
Open http://localhost:8080

### Deploy on minikube
See [Local Deployment Guide](docs/deploiement-local.md) for full instructions.

## Documentation
- [Architecture](docs/architecture.md)
- [CI/CD Pipeline](docs/ci-cd.md)
- [Local Deployment](docs/deploiement-local.md)
- [Terraform](docs/terraform.md)
- [Kubernetes](docs/kubernetes.md)
- [Ansible](docs/ansible.md)
- [Monitoring](docs/monitoring.md)
- [Exploitation](docs/exploitation.md)

## Team
- Narimen Boumaout — Application, Docker, CI/CD
- Melyssa Bertille — Infrastructure (Terraform, Kubernetes)
- Dihya Ouchene — Deployment (Ansible, Nginx, Monitoring)

## CI/CD
The pipeline runs automatically on every Pull Request and merge to main.
The Docker image is published to `ghcr.io/narimenb/locatic:latest`.