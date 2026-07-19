# CI/CD Pipeline

## Overview
The CI/CD pipeline is managed with GitHub Actions. It runs automatically on every push and pull request targeting main.

## Branch Protection Rules
- Direct pushes to main are blocked
- All changes must go through a Pull Request
- At least 1 approving review is required before merge
- Force pushes are blocked
- Delete of main is blocked

## How to Contribute
1. Create a feature branch from main
2. Make your changes and commit
3. Push your branch and open a Pull Request on GitHub
4. Wait for CI checks to pass
5. Request a review from a team member
6. After approval, merge the Pull Request

## Pipeline Jobs

### Job 1 — Build and Test
Triggers on every push and pull request.
- Checks out the code
- Sets up .NET 8
- Restores NuGet dependencies
- Builds the application

### Job 2 — Build and Push Docker Image
Triggers only when code is merged to main.
- Checks out the code
- Logs in to GitHub Container Registry
- Sets the image name to lowercase
- Builds and pushes the Docker image

## Image Registry
The Docker image is published to:

`ghcr.io/narimenb/locatic:latest`

## Limits
The pipeline does not deploy to minikube. Deployment is triggered locally using Terraform and Ansible after the image is published to the registry.