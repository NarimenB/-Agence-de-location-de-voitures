output "namespace" {
  value = kubernetes_namespace.locatic.metadata[0].name
}

output "sqlite_pv_name" {
  value = kubernetes_persistent_volume.sqlite_pv.metadata[0].name
}

output "storage_class" {
  value = kubernetes_persistent_volume.sqlite_pv.spec[0].storage_class_name
}