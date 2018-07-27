### Demo f�r Docker 
Die VS Console App inkrementiert alle 5 Sekunden den "Counter" im redis. Die folgenden Demos zeigen 

# Standalone
Redis l�uft in Docker. LongrunningApp l�uft �ber dotnet. Monitoring l�uft in node. 

- Redis starten `docker run --name redis -d --rm -p 6379:6379 redis`
- Jetzt normal die Visual Studio Console App starten
- Im Monitoring Verzeichnis `npm start`

#### Cleanup
- `docker container stop redis`

# Docker-Compose
Docker compose startet Redis und die LongrunningApp gemeinsam. Jeweils eine Instanz der App und von Redis werden gestartet. Die gesamte Konfiguration wird im docker-compose.yaml verwaltet.

- Im Longrunningapp Verzeichnis `docker-compose up -d --build`
- Im Monitoring Verzeichnis `npm start`

# Scale Longrunningapp
Skalieren der Longrunningapp auf 25 Instanzen parallel. Docker compose startet jetzt 25 Instanzen der Longrunningapp. Redis l�uft weiterhin nur in einer Instanz. Der Inkrement Counter 

- Im Longrunningapp Verzeichnis `docker-compose up -d --scale longrunningapp=25`

#### Cleanup
- `docker-compose down`
