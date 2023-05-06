# API-Labb4
## Get All People
*Request*
>/Get All People
```
curl -X 'GET' \ 
  'https://localhost:7249/Get All People' \ 
   -H 'accept: */*'
```
*Response*
```
[
  {
    "personID": 1,
    "name": "Justin Case",
    "email": "attorney@law.com",
    "phone": "0735466834"
  },
  ......
  ]
```
## Interests of people by their ID
*Request*
>/Interest By PersonID
```
curl -X 'GET' \
  'https://localhost:7249/Interest By PersonID?id=1' \
  -H 'accept: */*'
```
*Response*
```
[
  {
    "interestID": 1,
    "name": "Dancing",
    "description": "Move that body"
  },
  ......
  ]
```
## Links in interest by person ID
>/api/PeopleInterest/Links in interest by Person ID
```
curl -X 'GET' \
  'https://localhost:7249/api/PeopleInterest/Links in interest by person ID?id=3' \
  -H 'accept: */*'
```
*Response*
```
[
  {
    "linkID": 3,
    "url": "https://en.wikipedia.org/wiki/Fishing",
    "interestID": 3
  },
  ......
  ]
```
## New existing Interest for a Person
>/api/PeopleInterest/New Interest for person with id
```
curl -X 'POST' \
  'https://localhost:7249/api/PeopleInterest/New Interest for person with id?id=2&interestId=1' \
  -H 'accept: */*' \
  -d ''
```
*Response*
```
New Interest was Added
```
## New Link for a interest
>/api/PeopleInterest/New Link for Interest
```
curl -X 'POST' \
  'https://localhost:7249/api/PeopleInterest/New Link for Interest?interestId=2&link=https%3A%2F%2Fwww.crazygames.com%2F' \
  -H 'accept: */*' \
  -d ''
```
*Response*
```
New Link was added to interest
```


