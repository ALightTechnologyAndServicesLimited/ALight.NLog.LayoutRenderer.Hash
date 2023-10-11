# ALight.NLog.LayoutRenderer.Hash
 
This library allows hashing any sensitive information in logs.

This library provides two Layout Renderers hash and securehash.

hash uses Murmur3 non-cryptographic hash algorithm, securehash uses SHA256 cryptographic algorithm.

~~Murmur3 is about 10 - 11 times faster than SHA256 and can be used for non-sensitive data. I think very sensitive data should not be logged anyway.~~

The source code contains few unit tests and Benchmarks.

Anouncement Blog: [Opensource NLog Hash LayoutRenderer](https://blog.alightservices.com/2023/10/opensource-nlog-hash-layoutrenderer.html)

Technical Blog: [Custom Layout Renderer for NLog using C# New](https://blog.alightservices.com/2023/10/opensource-nlog-hash-layoutrenderer.html)



**v0.0.2 Enhancements:**

Improved memory allocation by object pools.

Improved performance due to less overhead of object creation

Now Murmur3 is just 3 times faster than SHA256 due to significant speed improvement of SHA256 and little slowdown of Murmur3.

SHA256: 2.5 times faster, 30% lesser memory allocation

Murmur3: 20% slower, 16% lesser memory allocation



**Planned enhancements:**

- Configurable Object pool use, default objectpool for SHA256, no objectpool for Mumur3.


### Personal Links:
[Facebook - Kanti Arumilli](https://www.facebook.com/kanti.arumilli)

[LinkedIn - Kanti Kalyan Arumilli](https://www.linkedin.com/in/kanti-kalyan-arumilli/)

[Twitter](https://twitter.com/KantiKalyanA/)

[Thread](https://www.threads.net/@kantiarumilli)

[Youtube](https://www.youtube.com/@kantikalyanarumilli)

+91-789-362-6688, +1-480-347-6849, +44-3333-03-1284, +44-07718-273-964

### Startup Links:
[ALight Technology And Services Limited](https://www.alightservices.com/)

[Facebook](https://www.facebook.com/ALightTechnologyAndServicesLimited/)

[LinkedIn](https://www.linkedin.com/company/alight-technology-and-services-limited/)

[Youtube](https://www.youtube.com/@alighttechnologyandservicesltd)
