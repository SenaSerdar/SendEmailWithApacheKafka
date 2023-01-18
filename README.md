# SendEmailWithApacheKafka
Docker Comands

docker network create kafka-network --driver bridge

docker run -d --name zookeeper-server  --network kafka-network  -e ALLOW_ANONYMOUS_LOGIN=yes   bitnami/zookeeper:latest

docker run -d --name kafka-server   --network kafka-network   -e ALLOW_PLAINTEXT_LISTENER=yes  -e KAFKA_CFG_ZOOKEEPER_CONNECT=zookeeper-server:2181   bitnami/kafka:latest

docker run -d --rm -p 9000:9000   --network kafka-network   -e KAFKA_BROKERCONNECT=kafka-server:9092  -e SERVER_SERVLET_CONTEXTPATH="/"  obsidiandynamics/kafdrop:latest

Sample view of Kafdrop 
-you can create a topic with +new and manage ur queues from this UI.  
<img width="1324" alt="Screen Shot 2023-01-18 at 10 39 01" src="https://user-images.githubusercontent.com/53566797/213111954-ca89a71f-9991-4279-82ac-60c2355ae458.png">

Create Topic From clı

docker run --rm bitnami/kafka kafka-topics.sh --create --topic firstTopic --replication-factor 1 --partitions 1  --bootstrap-server localhost:9092

