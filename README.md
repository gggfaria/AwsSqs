# AWS SQS Implementation

This repository has two projects, one REST API to send messages to a SQS queue service, and one Consumer service.

## API
### Publisher 
[Sqs.Api](./Sqs.Api/)

MessageController "/message"
- CreateMessage [POST] : Publish CreateMessage type in an SQS service

Request Json:

```json
{
    "Id": "e01a8a10-5793-41f6-9bf4-e7c1c3e056eb",
    "MessageText": "Frodo"
}
```


- UpdateMessage [PUT] : Publish UpdateMessage type in an SQS service 

Request Json:

```json
{
    "Id": "e01a8a10-5793-41f6-9bf4-e7c1c3e056eb",
    "MessageText": "Bilbo"
}
```

- DeleteMesssage [DELETE] : Publish DeleteMessage type in an SQS service 

Request URL:
```
/message/e01a8a10-5793-41f6-9bf4-e7c1c3e056eb
```

## Consumer Service
[Sqs.Consumer](./Sqs.Consumer/)

This project uses lib MediatR 12 to implement Mediator Pattern. 

The QueueConsumerService reads the SQS queue and sends the message to Mediator, which implements 3 Handlers. 
[Handlers](./Sqs.Consumer/Handlers/)

Each one of them decides how to deal with the message received.

 - Delete
 - Update
 - Create


 ## Running  

 To run the project you have to configure AWS settings in your machine with your credentials. 

 After that, configure a queue named "message", or you can change the QueueSettings > Name in appsettings.json 
 
 [Sqs.Consumer AppSettings](./Sqs.Consumer/appsettings.json)
 
 [Sqs.Api AppSettings](./Sqs.Api/appsettings.json)

