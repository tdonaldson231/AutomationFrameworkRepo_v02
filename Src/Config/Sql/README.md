# Local SQL Instance

## Usage

To start the MySQL container:
```bash
docker-compose up -d --build
```

**Note**: Open docker desktop and verify the `test-mysql` container is running.

To stop and remove the container:
```bash
docker-compose down
```

If you want to remove all data (clean start):
```bash
docker-compose down -v
```