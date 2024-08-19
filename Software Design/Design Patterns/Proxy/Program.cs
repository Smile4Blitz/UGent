using Proxy;

ISubject Subject = new AuthenticationProxy(new VirtualProxy());
Subject.Operation();
Subject.Operation();