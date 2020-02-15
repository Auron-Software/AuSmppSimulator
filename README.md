# AuSmppSimulator
Auron Software SMPP Simulator. SMPP Server for load testing SMPP client software.

This is an easy to use C# Windows Forms based SMPP Server simulator. It is released by Auron Software as an open-source project. It makes use of the Auron Software SMS Component for the SMPP server implementation.

With this SMPP Simulator you can test:
  - Number of SMS received/send per second
  - Different character encoding settings
  - Binary, UDH, WAPPush and normal multipart messages
  - Failure modes and throttling effects
  - Generate delivery reports
  - Randomly generate delivery report status distributions
  - Automatically send template messages at given TPS
  - Automatically echo template messages

SMPP is used for sending and receiving SMS text messages through the internet. The procol is designed for high performance and used between SMSC's and aggregators as well business software that connects directly to an SMS provider or SMSC.
