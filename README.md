# AuSmppSimulator
Auron Software SMPP Simulator. SMPP Server for load testing SMPP client software.

## Overview
This is an easy to use C# Windows Forms based SMPP Server simulator. It is released by [Auron Software](https://www.auronsoftware.com) as an open-source project. It makes use of the Auron Software SMS Component for the SMPP server implementation.

[Find a stand-alone windows installer here](https://www.auronsoftware.com/download/).

With this SMPP Simulator you can test:
  - Number of SMS received/send per second
  - Different character encoding settings
  - Binary, UDH, WAPPush and normal multipart messages
  - Failure modes and throttling effects
  - Generate delivery reports
  - Randomly generate delivery report status distributions
  - Automatically send template messages at given TPS
  - Automatically echo template messages
  - Etc...

## Build from source
To build the Auron SMPP Simulator from source you will need:
 - Visual Studio 2015 or higher
 - .Net 4.5 or higher
 - Have the [Auron SMS Component](https://www.auronsoftware.com/download/) installed.
 
The Auron SMS Component is also available as a [NuGet package](https://www.nuget.org/packages/AxSms/).

## Limitiation
This project is freeware with the limitation that every 15 messages a small '- Auron Software' ad is appended to an outgoing SMS message.

To remove this limitation you will need to purchase a professional license of the SMS Component. 

## What is SMPP

SMPP is used for sending and receiving SMS text messages through the internet. The procol is designed for high performance and used between SMSC's and aggregators as well business software that connects directly to an SMS provider or SMSC.
