# Monitoring Documentation

## Overview

The project uses Prometheus and Grafana to monitor the Locatic application and Kubernetes resources.

The monitoring stack helps to collect metrics, visualize system status and detect possible issues.

## Monitoring Services

The monitoring solution contains:

- Prometheus
- Grafana

Prometheus is responsible for collecting metrics.

Grafana is used to display dashboards and visualize monitoring data.

## Monitored Services

The following components are monitored:

- Locatic application pods
- Kubernetes nodes
- Kubernetes services
- Application availability
- Resource usage

## Metrics Collected

The main metrics include:

- CPU usage
- Memory usage
- Pod status
- Container health
- Service availability
- Kubernetes resource information

## Prometheus Deployment

Prometheus is installed using Helm with the Prometheus Community charts.

Installation command:

```bash
helm install monitoring prometheus-community/kube-prometheus-stack \
--namespace monitoring \
--create-namespace \
-f monitoring/prometheus/values.yaml