﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;

namespace WcfService
{
    public class HttpSoap12TestServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            HttpSoap12TestServiceHost serviceHost = new HttpSoap12TestServiceHost(serviceType, baseAddresses);
            return serviceHost;
        }
    }
    public class HttpSoap12TestServiceHost : TestServiceHostBase<IWcfService>
    {
        protected override string Address { get { return "http-soap12"; } }

        protected override Binding GetBinding()
        {
            return new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8), new HttpTransportBindingElement());
        }

        public HttpSoap12TestServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }
    }
}
