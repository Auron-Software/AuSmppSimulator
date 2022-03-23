//-----------------------------------------------------------------------
// <copyright file="SimConstants.cs" company="Auron Software">
//     Copyright (c) Auron Software All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace SmppSimulator
{
  using System.Drawing;

  static class SimConstants
  {
    //Misc
    public const int WORKER_UPDATE_MS = 500;
    public const string SIMULATOR_FREEWAYREGKEY = @"SOFTWARE\Auron\Freeware\SmppSimulator";
    public const int ADDREFERENCES_ONAPPSTART = 100;
    public const string DEFAULT_FROMADDRESS = "123456789";

    // Registry constants
    public const string REGISTRY_MAX_MESSAGES_TO_SEND_KEY = "MaxMessagesToSend";
    public const string REGISTRY_MESSAGE_FAILURE_STATES = "MessageFailureStates";
    public const string REGISTRY_DELIVERY_FAILURE_STATES = "DeliveryFailureStates";

    // Message State constant
    public const string MESSAGE_STATE_PENDING = "Pending";
    public const string MESSAGE_STATE_SENT = "Sent";
    public const string MESSAGE_STATE_FAILED = "Failed";
    public const string MESSAGE_STATE_DENIED = "Denied";

    //ActiveXperts SMS Component required build.
    public const string AXSMS_REQ_BUILD = "7.0";        // %SWITCH|%VERSION%|7.0%

    // Message Direction Constants
    public const string MESSAGE_DIRECTION_OUT = "Out";
    public const string MESSAGE_DIRECTION_IN = "In";

    // XML AutoReplyMessages constants
    public const string XML_AUTOMESSAGE_ROOT_NODE = "AutoReplyMessages";
    public const string XML_AUTOMESSAGE_ELEMENT_NODE = "Message";
    public const string XML_AUTOMESSAGE_FIELD_TOADDRESS = "ToAddress";
    public const string XML_AUTOMESSAGE_FIELD_TONPI = "ToNpi";
    public const string XML_AUTOMESSAGE_FIELD_TOTON = "ToTon";
    public const string XML_AUTOMESSAGE_FIELD_FROMADDRESS = "FromAddress";
    public const string XML_AUTOMESSAGE_FIELD_FROMNPI = "FromNpi";
    public const string XML_AUTOMESSAGE_FIELD_FROMTON = "FromTon";
    public const string XML_AUTOMESSAGE_FIELD_BODY = "Body";
    public const string XML_AUTOMESSAGE_FIELD_HASUDH = "HasUDH";
    public const string XML_AUTOMESSAGE_FIELD_ISDLR = "IsDeliveryReport";
    public const string XML_AUTOMESSAGE_FIELD_DATACODING = "DataCoding";
    public const string XML_AUTOMESSAGE_FIELD_BODYFORMAT = "BodyFormat";
    public const string XML_AUTOMESSAGE_FIELD_LANGUAGESHIFT = "LanguageShift";

    public const string XML_AUTOMESSAGE_ELEMENT_TLV = "Tlv";
    public const string XML_AUTOMESSAGE_FIELD_TAG = "Tag";
    public const string XML_AUTOMESSAGE_FIELD_TYPE = "Type";
    public const string XML_AUTOMESSAGE_FIELD_HEXVALUE = "HexValue";
    public const string XML_AUTOMESSAGE_FIELD_TYPEDVALUE = "TypedValue";


    // XML Failure Rates constants
    public const string XML_FAILURE_ROOT_NODE = "FailureRates";
    public const string XML_FAILURE_ELEMENT_MESSAGE_STATES = "MessageStates";
    public const string XML_FAILURE_ELEMENT_MESSAGE_STATE = "MessageState";
    public const string XML_FAILURE_ELEMENT_DELIVERY_STATES = "DeliveryStates";
    public const string XML_FAILURE_ELEMENT_DELIVERY_STATE = "DeliveryState";
    public const string XML_FAILURE_FIELD_DELIVERY_CODE = "Code";
    public const string XML_FAILURE_FIELD_DELIVERY_OCCURANCE = "Occurance";
    public const string XML_FAILURE_FIELD_MESSAGE_CODE = "Code";
    public const string XML_FAILURE_FIELD_MESSAGE_OCCURANCE = "Occurance";

    public const string ATOM_FREEWAREMODE = "Auron SMPP Simulator; Insert Advertisements";

    public const int MODEL_DEFAULT_MAX_MESSAGES_TO_SEND = 1000;

    // ErrorCodes constants
    public const int ERRORCODE_MESSAGEQUEUEFULL = 36721;
    public const int ERRORCODE_SMS_NO_SMS_SUBMITTED = 36706;
    public const int ERRORCODE_SMS_NO_DELIVERY_RESPONSES = 36708;
    public const int ERRORCODE_SESSIONS_NO_MORE_CONNECTED = 36710;
    public const int ERRORCODE_NOMORE_CERTIFICATES = 33233;

    public static readonly Color COLOR_ACTIVEXPERTS_RED = Color.FromArgb(204, 0, 0);
    public static readonly Color COLOR_MESSAGE_QUEUE_FULL_RED = Color.FromArgb(255, 50, 50);
  }
}
