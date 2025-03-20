## Monitoring Setup

local setup includes: 
✅ Grafana for visualization
✅ Prometheus for storing metrics
✅ OpenTelemetry for collecting metrics
✅ A sample Flask app generating telemetry data

### Local Setup / Usage

To start the Monitoring containers:
```bash
docker-compose down
docker-compose build --no-cache
docker-compose up -d

```

### View Metrics in Prometheus and Grafana
- Prometheus: http://localhost:9090 (Search for http_requests)
- Grafana: http://localhost:3000
	- Configure Prometheus as a data source (http://prometheus:9090)
	- Create a dashboard to visualize http_requests

Note: a new password is required after logging into Grafana the first time.

### Test the Application

Open your browser and visit:

- Sample App: http://localhost:5000

Each visit will generate OpenTelemetry metrics.


### otel-collector-config.yaml
- receivers.otlp: Allows the OpenTelemetry Collector to receive data from applications (OTLP over gRPC & HTTP).
- receivers.prometheus: Scrapes metrics from your sample app running on app:5000.
- processors.batch: Batches data to improve performance.
- exporters.prometheus: Exposes collected metrics at http://otel-collector:9464, where Prometheus can scrape them.
- exporters.otlp: (Optional) Sends telemetry data to another OTLP collector.
- service.pipelines.metrics: Defines the full flow of metrics from receivers → processors → exporters.