# RabbitMQ Example from Official Documentation

- [Requirements](#requirements)
- [How To Run](#how-to-run)
- [Sample Run Case](#sample-run-case)

## Requirements

- [RabbitMQ](https://www.rabbitmq.com/) installed in computer.
- [.NET Core 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) installed in computer.

## How To Run

- You can run the clients in any order, as both declares the queue.

- Open a terminal in project directory and run `dotnet-cli` commands below

- For getting required packages:

```bash
dotnet restore
```
- For sending message to queue:

```bash
dotnet run --project RabbitMQExample.Sender
```

- For receiving messages from queue:

```bash
dotnet run --project RabbitMQExample.Receiver
```

### Sample Run Case

- Open a terminal in project directory and run `RabbitMQExample.Sender` project with following command.

```bash
dotnet run --project RabbitMQExample.Sender
```
- Output of this project should be:
```
Message sent to queue!
```

- You can check `RabbitMQ Management` web page to see activity.

- Then run `RabbitMQExample.Receiver` project with following command.

```bash
dotnet run --project RabbitMQExample.Sender
```

- Output of this project should be:
```
Waiting for messages...
Press Enter to Exit!
Received Message: VBT RabbitMQ Example
```

- Once you start `RabbitMQExample.Receiver` project, it will listen the queue until you press `enter` in terminal and will receive one message after every run of `RabbitMQExample.Sender` project.
