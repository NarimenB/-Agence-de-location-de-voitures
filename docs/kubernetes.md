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
```yaml
DB_PATH: "Data Source=/app/data/locatic.db"
```
This matches what's read in `Program.cs`:
```csharp
var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "Data Source=locatic.db";
```

## Health check
A `/health` endpoint was added to the app (`Program.cs`) so Kubernetes can verify the container is responding correctly:
```csharp
builder.Services.AddHealthChecks();
// ...
app.MapHealthChecks("/health");
```
It's used by the readiness and liveness probes in `deployment.yaml`.

## Image
In production, the image should be the one published by the CI pipeline:
```yaml
image: ghcr.io/narimenb/locatic:latest
```

### Issue encountered: CPU architecture compatibility
The image initially published by the CI pipeline was built only for `linux/amd64` (GitHub runners' architecture). On an Apple Silicon machine (arm64), the pod crashed with: