﻿using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace TccBackendUmc.Utility.Security;

public static class RsaSecurity
{
    public static RsaSecurityKey GetPublicSigningKey(this RSA rsa)
    {
        var publicXmlKey = @"<RSAKeyValue>
	<Modulus>s1IA2Ft1oX8VUkxW74MZN94TBlyUjDbjDSTJ9fhYiHqMa1fgZePlV2DQg4FEqptZqkE0zBlWfsBP4CBvl5MFMTCHs0qpNzBVeF2ypyzxKeM6POTO6HREPbQK1CkeWOLcxkCyEspWxY381cpedtqtzcrr6Fchdp4T31E3EJYyC3w+2Ch68r+a8jiQSmPTZ8LXF0bo85xN23bYMwVTUQTKVVE0yKV2N24o9vMx+s7rfnSotKXQWUmlYMmBuhcgM5Nt5wPTFZghIFAEJYC4saK838tG3E6PqtoLRPaajgD4Ow7Mrr9spipGbONWHUFYBRkcsTVWtwkOxAs3TkUnfoE5tQn2iW0pWRw8TWpBBQnkY3GPcGpI38gW5QPgwcimwTjYJBrATSINwfSFQ+s3+/A/TmvwHFfrd6F8p4CTpbRffg44GwISRTvt+LpXSC37eqP1UodUJrBOUgLAB15YXoEyVxbZpBqYagGCsntS9zcf4YM4+Op1LrxsndCpMgwDS4e715DsQsp/Jw5CW+4o0aB5ntyLmQ9pAJRdPnNrvv+QGFQqJ7CJq2fFiMSx3zM7OTvi62Q3ExgeGuDmPUDMr9bQmGfd/V8RwVGP4RajRfm4v09vCgU/MlfTHT+3PAZdqMQKiqVT8T3P/bdP3JPZX3WGaF1LLBanuC+tp0LHsvftL/c=</Modulus>
	<Exponent>AQAB</Exponent>
</RSAKeyValue>";
        rsa.FromXmlString(publicXmlKey);

        return new RsaSecurityKey(rsa);
    }

    public static RsaSecurityKey GetPrivateSigningKey(this RSA rsa)
    {
        var publicXmlKey = @"<RSAKeyValue>
	<Modulus>s1IA2Ft1oX8VUkxW74MZN94TBlyUjDbjDSTJ9fhYiHqMa1fgZePlV2DQg4FEqptZqkE0zBlWfsBP4CBvl5MFMTCHs0qpNzBVeF2ypyzxKeM6POTO6HREPbQK1CkeWOLcxkCyEspWxY381cpedtqtzcrr6Fchdp4T31E3EJYyC3w+2Ch68r+a8jiQSmPTZ8LXF0bo85xN23bYMwVTUQTKVVE0yKV2N24o9vMx+s7rfnSotKXQWUmlYMmBuhcgM5Nt5wPTFZghIFAEJYC4saK838tG3E6PqtoLRPaajgD4Ow7Mrr9spipGbONWHUFYBRkcsTVWtwkOxAs3TkUnfoE5tQn2iW0pWRw8TWpBBQnkY3GPcGpI38gW5QPgwcimwTjYJBrATSINwfSFQ+s3+/A/TmvwHFfrd6F8p4CTpbRffg44GwISRTvt+LpXSC37eqP1UodUJrBOUgLAB15YXoEyVxbZpBqYagGCsntS9zcf4YM4+Op1LrxsndCpMgwDS4e715DsQsp/Jw5CW+4o0aB5ntyLmQ9pAJRdPnNrvv+QGFQqJ7CJq2fFiMSx3zM7OTvi62Q3ExgeGuDmPUDMr9bQmGfd/V8RwVGP4RajRfm4v09vCgU/MlfTHT+3PAZdqMQKiqVT8T3P/bdP3JPZX3WGaF1LLBanuC+tp0LHsvftL/c=</Modulus>
	<Exponent>AQAB</Exponent>
	<P>9/W9HG8uzsS2fLEO4JLxKgqb2IJBEHyO10HVjhju4ZwX+l7C/7XwD2VdW2YOyFqLYWhsi3knT+enT7CezYVxrJOQAFzGl0vPutiugmkqsIGbTYTs2pftFX5Uk4UT5lkO2Kjab4xwcE4QnETyPWvYck2Sg1V3l+qu69oh4Uay1oGiUwGCo4TR8g5o1MQHJFz4WWiPfWqY6WqftL6RSCPaWmCfsL0Dsn18XjYwXH86MwNzZ4/MUtbOFKmNGWO0PEtjjVa/H7RARGWrilJG66Wl1udRu37Xsbgvbnv08oPyrADfefBFPibGd3tV068DiTMtnOa38qi6cIqBm2HJsN9e3w==</P>
	<Q>uSKAlYTtgL/ETi8no9Qu/Blr9cmYeo8G86BtD5pusvaFXsFoPulai4bs6QYuIFc1uFRsRaZmpBIdn3ByuSESVMbZj6ZCfpSWd+XHYu6Hi5oFchSEGTUUpERAAjtWsikBsA5B6a1GwXZeQVu6em5zOiaJlvzu2MYi1OClngZD4srQ89iC36fJr/d2SHFuwDxtD2LlT6ac1y3NFAiz7QaocjmIEpA9zqgeB1aoXFNDo2veit3Zbdb+SEf54//Oo8s1YONiZwNoPE1XYcim7TFe3jz/32tzRWXb5L7S6SFpU5/ybNOtM1PIniG2KytNfugGfWuKjvaroMI8Z4RTCPYJ6Q==</Q>
	<DP>6sBuP+NLL1qxYi/G4/p589GDZmE69D7YhRbA9fzI/DNpyBG7D5jSI+FVl1hyGmEOoDPav9j9zPqGPj36upzh1/8EUDOFmGufyUenP7QNRHoP7D4yd2lqffTSYa+V/XjHQ3vpAb62HLzroObtaBUYIG8sjMZ3qQ34eTZU6RCj881bPrapVeJDWaUmvniwQk76mLsTTiuDhUj61oWsyd2XtgTQauUoAO4otpEbDBcvpGhZ8+wCB1NyW8GB4k2wr3y4TXGZFIz0Y0zWMOhgWGzFK0Zo7NfToV+9GB6m8orVTt6stKczBvpy31+XDAgfkt8vCeKsuEHh8PZQaikUaC2xhQ==</DP>
	<DQ>pHFFDYo4+7daQqgX6ak64qoh/vvF+Ha6kgPZW5as5UGbTYM1eUwFJRH/tSvMJOXRzZ0PXv5jBTEiJtDW1iHOCodmD/Z58b1BudXbuMBunU19sMsQWuOPJimJQXI7m5xY52yCl3FV+9mL9znm9YDN0MUSSY75CItVvQidkzO1cOj9mNqjxM1glHCWG9rFqPMDXDtXu9weS/NeyYDBcLQNQwhfGT4N6FXj9li+yuManTnfPjG4Q5xH2SQ1jpNVlJ+XFixi52VbXNTF3RFBVEYaIgTEskra5LWJEDF/XZxT1feoeYm7um+dLvh6uvWHrEWkHhs7w6jO4cglpz0eFEOWoQ==</DQ>
	<InverseQ>AbVQzvvydIzDf7UiUgaHOaG71LXMh7c6qJCV45CjQU9QPLOMI+0UsIn6brh0dhcjpJYJUimFEEoV0lopjAaFb4XSjwJ5Dv87d4Mfkoh37a6/KL0mT0ygyKjTNdw8h9BQ2VxArCNBhtLZEFkMhaSYsYcNwC7QLmpZjGiQkonK6bYhH2oqAX2Sn/NZbu6QvApEvT094x5/peQPHqYnZGA11sdsrXGUvS6bx7SulJ24IyboeZIMcRTgdaokn7Ob3ZnBJkL3Ny+3Ctq2b/iujSaAiPwwn2bBrYzZG//r0VupSej1pyN8K1BvXAYwBi5txvN02tcBsFs9e3o08WVjuXTn5Q==</InverseQ>
	<D>khbsuVdJrhhqtnGbIeYcVXeG6FfkbZcJw1uFbe61sfqlC468MkZIQbeOKJTX7GZD1oDpEp5R6VGjwWSrhUExqbFv3JGm6l9mQnmTYr8qeoW0nIeMSbTvI5XafJ5DKwcn9hwe91ABAVF7+nC0JQBjOJVpPBBAIvMGHZl80vaKLvE6AcB46etPwKZ0ZyaMxKvnr/8FKfLdOz7HREnCZu8QKBHQfubOOLp2hTn8LekF0jAYgZPU+ekV4pRIK+NLSLmDgAGNproZwsltl2AXGCEM3wYs5K7cPMUHCVge8jG4CeU0u+kYCwfF+E/9iDgEDaM3zOc3jkbC0NSSaiHM2zNMXuC3udr6tF3UJLPTmm0GcByxlLgAm2SAIjq8m73SLAtY2UBFxVYUWQeVqU5KD4eHuuqM+SaIWggR6aO1RSM63/w7YKUb5FTcGdR+nFKxnEN/B2dApW69qzrLwQfLQ9r+QXzqhM7055h32X5QEoE9n6UpHPw0WhnZFZalFgktQkosVfhCg8nnZc74OHfCy6l0M1op32BtRcDhSC9NcCuENx4KIuaToXNSOFErSOvRB1rPouMgxwPFazH128dvmEIppgjjhefs/uqqBhWAnsurGus4lKWMJjSTT9bqTXnATEp4FxqpFVxC/a6ej2/Tm11pSVqGj0XrUXuOWHjCwDQ2CwE=</D>
</RSAKeyValue>";
        rsa.FromXmlString(publicXmlKey);

        return new RsaSecurityKey(rsa);
    }
}