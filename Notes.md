## What we'll cover
+ What's caching and why Redis is used (theory)
+ Redis Datatypes
+ Setting up Redis in a container
+ Using Redis as a primary DB with a .NET 6 API

## What is Redis?
+ A Key / Value Datastore
+ Synonymous with Caching
+ Reputation for being incredibly fast due to:
    + Lightweight simple architecture
    + Key / Value retrieval
    + In Memory

## Redis Data Types
+ Strings
+ Lists
+ Hashes
+ Sets
+ Sorted Sets
+ [DataTypes Docs](https://redis.io/topics/data-types-intro)

## [Redis Documentation](https://redis.io/documentation)

## Redis Keys
+ Binary Safe
    + You can use any binary sequence as a key
+ Very long keys are not a good idea
    + Memory impact (max size 512MB)
    + Look up performance
+ Very short keys are not a good idea either
    + Should be readable with a structured "Schema"
    + object-type:id works well e.g. user:234432

## Caching
+ No Hit (no caching available for requested resource)

## Redis as a Primary DB
+ Redis does more than act as a cache, it can also operate as a:
    + Database
    + Message Broker
+ Reputation as an "In Memory" store can mislead...
+ Redis **does offer** a number of approaches to data persistence
    + You don't loose your data if Redis restarts etc...
 
 ## Application Architecture
 + We're not making use of DTOs in this example
 + We're using: IConnectionMultiplexer
 + You could use: IDistributedCache
 + Only implementing GET, and POST endpoints

 ## Strings
+ Simplest type of value to be associated to a key
+ 1 to 1 mapping between Key and Value
+ Useful for a number of use cases
+ Set using SET
    + SET <key><somevalue>
    + GET <key>
    + del <key>

## Which Package?
+ Microsoft.Extensions.Caching.Redis (Deprecated)
+ Microsoft.Extensions.StackExchangeRedis
    + IDistributedCache (restricted datatypes)
    + IConnectionMultiplexer (all datatypes available)
+ StackExchange.Redis
    + IConnectionMultiplexer (all datatypes available)


## Getting all resources

1. Use the SCAN command
2. Use Sets as well as Strings...
    + Existing GetPlatformById method continues as before (using Strings)
    + New GetAllPlatforms method would return a SET of all objects
3. Refactor our code to only use HASHES

## Sets
+ Unordered collections of Strings
+ 1 to many mapping betwen key and value
+ Set using SADD
    + Sadd myset 1 2 3
+ Returned using SMEMBERS
    + smembers myset
+ Check if value present in set SISMEMBER

+ Good for constructing relations between other entities

## Hashes
+ Stores Field / Value pairs
+ Suitable for storing structure objects
+ Set using HMSET
    + hmset <id> <field1><value1>
+ Get all items using HGETALL
    + hgetall <id>
+ Get individual items using HGET
    + hget <id><field1>