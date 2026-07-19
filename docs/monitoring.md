# Monitoring Documentation

## Overview

The monitoring system is used to monitor the Locatic application deployed on Kubernetes.

The monitoring stack uses Prometheus and Grafana.

## Monitoring Components

The monitoring architecture contains:

- Prometheus: collects application and Kubernetes metrics.
- Grafana: displays metrics using dashboards.

## Prometheus

Prometheus is responsible for collecting metrics from Kubernetes services.

It helps to monitor:

- Application availability
- Kubernetes pods status
- CPU usage
- Memory usage
- Service health


## Grafana

Grafana provides dashboards to visualize monitoring information.

The dashboard can display:

- Locatic application status
- Nginx status
- Kubernetes resources
- System performance


## Installation

The monitoring stack is installed using Helm.

Add the Prometheus repository:

```bash
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts