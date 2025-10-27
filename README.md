### 📨 Background Queue com RabbitMQ

Estudo prático sobre mensageria e processamento assíncrono usando RabbitMQ com C#/.NET.
O objetivo é entender o fluxo de mensagens entre produtores e consumidores e a importância do desacoplamento entre serviços.

#### 🚀 Tecnologias

.NET 6
RabbitMQ
Docker (para subir o broker)
Hosted Services / BackgroundWorker

#### ⚙️ Funcionalidades
Produção e envio de mensagens a uma fila RabbitMQ
Consumo de mensagens em segundo plano via HostedService
Logs e confirmação de mensagens (ACK/NACK)
Simulação de múltiplos consumidores

#### 🧩 Estrutura
```
background-queue-rabbitMQ/
├── Producer/  → Serviço responsável por publicar mensagens
├── Consumer/  → Serviço que consome mensagens da fila
└── Shared/    → DTOs e abstrações comuns
```

#### 🧰 Executando localmente

- Suba o RabbitMQ via Docker:
```bash
docker run -d --hostname rabbit --name rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

- Configure o appsettings.json com o host local (localhost, porta 5672).

- Rode o produtor e o consumidor separadamente:
```bash
dotnet run --project Producer
dotnet run --project Consumer
```

- Acompanhe os logs de envio e processamento de mensagens.

#### 🎯 Objetivo do projeto

Este projeto foi desenvolvido com o intuito de estudar comunicação assíncrona entre serviços, fila de mensagens e resiliência de sistemas distribuídos.
Ele demonstra conceitos fundamentais usados em arquiteturas modernas baseadas em eventos.
