terraform {
  required_providers {
    kubernetes = {
      source  = "hashicorp/kubernetes"
      version = "~> 2.29"
    }
  }
}

provider "kubernetes" {
  config_path    = var.kube_config_path
  config_context = var.kube_context
}

resource "kubernetes_namespace" "locatic" {
  metadata {
    name = var.namespace
  }
}

resource "kubernetes_persistent_volume" "sqlite_pv" {
  metadata {
    name = "${var.namespace}-sqlite-pv"
  }

  spec {
    capacity = {
      storage = var.sqlite_storage_size
    }
    access_modes                     = ["ReadWriteOnce"]
    persistent_volume_reclaim_policy = "Retain"
    storage_class_name               = "manual"

    persistent_volume_source {
      host_path {
        path = var.sqlite_host_path
      }
    }
  }
}