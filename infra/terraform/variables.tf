variable "kube_config_path" {
  description = "Path to the kubeconfig file"
  type        = string
  default     = "~/.kube/config"
}

variable "kube_context" {
  description = "Kubernetes context to use"
  type        = string
  default     = "minikube"
}

variable "namespace" {
  description = "Namespace for the Locatic app"
  type        = string
  default     = "locatic"
}

variable "sqlite_storage_size" {
  description = "Size of the persistent volume for SQLite"
  type        = string
  default     = "1Gi"
}

variable "sqlite_host_path" {
  description = "Path on the minikube node used to store the SQLite volume"
  type        = string
  default     = "/data/locatic-sqlite"
}