# Monitoring Setup

## Overview

The monitoring stack is based on Prometheus and Grafana.

Prometheus collects metrics and Grafana displays dashboards.

## Components

The monitoring stack contains:

- Prometheus server
- Grafana dashboard
- Kubernetes metrics collection


## Installation

Create the monitoring namespace:

```bash
kubectl create namespace monitoring