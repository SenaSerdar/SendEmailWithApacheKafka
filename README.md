# SendEmailWithApacheKafka
Docker Comands

docker network create kafka-network --driver bridge

docker run -d --name zookeeper-server  --network kafka-network  -e ALLOW_ANONYMOUS_LOGIN=yes   bitnami/zookeeper:latest

docker run -d --name kafka-server   --network kafka-network   -e ALLOW_PLAINTEXT_LISTENER=yes  -e KAFKA_CFG_ZOOKEEPER_CONNECT=zookeeper-server:2181   bitnami/kafka:latest

docker run -d --rm -p 9000:9000   --network kafka-network   -e KAFKA_BROKERCONNECT=kafka-server:9092  -e SERVER_SERVLET_CONTEXTPATH="/"  obsidiandynamics/kafdrop:latest
