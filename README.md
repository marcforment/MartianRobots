# MartianRobots
The code challege has been implemented as a Dockerized .NET CORE API

## Table of contents
1. [Additional functionality](#Additional-functionality)
2. [How to run the solution](#How-to-run-the-solution)
3. [Example requests](#Example-request)

## Additional functionality <a name="Additional-functionality"></a>
In addition to the minimum required fuctionality an exploration score feature has been added that determines the quality of the exploration operation made by the robots. Given an input each explored coordinate on Mars adds 1 point. Visiting an already explored coordinate subtracts one point from the final score. Here are two examples:

- Robots visit (1,0), (1,1) and (2,3):
    - (1,0) 1 point
    - (1,1) 1 point
    - (2,3) 1 point
        - Total: 3 points

- Robots visit (1,0), (1,1) and (1,0) again:
    - (1,0) 1 point
    - (1,1) 1 point
    - (1,0) -1 point
        - Total: 1 points

Scores for each execution are stored in memory and the previous top score is returned on the response.

## How to run the solution <a name="How-to-run-the-solution"></a>
To run the solution go to MartianRobots/MartianRobots.Web and execute:
```
docker build -f Dockerfile --force-rm -t martianrobots  ..
docker run -it --rm -p 5000:80 --name martianrobots martianrobots
```

## Example request <a name="Example-request"></a>
To make a request to the API using the example input from the code challenge spacification, you can use the following curl: 
```
curl --location --request POST 'http://localhost:5000/explore' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Input":"5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL"
}'
```
Expected output:
```
{
    "result": "1 1 E\n3 3 N LOST\n4 2 N",
    "scoreResult": 5,
    "previousTopScore": 0
}
```