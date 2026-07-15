# Kubernetes resources

## Overview
These manifests deploy the Locatic application inside the `locatic` namespace created by Terraform.

Files (in `k8s/`):
- `configmap.yaml`: environment variables used by the app (ASP.NET Core config, SQLite DB path)
- `pvc.yaml`: PersistentVolumeClaim bound to the PersistentVolume created by Terraform, used to persist the SQLite database file
- `deployment.yaml`: Deployment running the app container, with the SQLite volume mounted, health probes and resource limits
- `service.yaml`: ClusterIP Service exposing the app internally, used as the target for the Nginx reverse proxy

## Storage
The SQLite database file is stored at `/app/data/locatic.db` inside the container, mounted on the `locatic-sqlite-pvc` volume so the data survives pod restarts.

## Configuration
The app reads its DB path from the `DB_PATH` environment variable, set in `configmap.yaml`: