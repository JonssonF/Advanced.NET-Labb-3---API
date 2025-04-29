# 📚 Lab 3 - REST API

This project is a REST API built with .NET 8 and Entity Framework Core.  
The API manages **Persons**, **Interests**, and **Links** associated with a person's interests.
---

## 🚀 Features

- Retrieve all persons
- Retrieve interests linked to a specific person
- Retrieve links linked to a specific person
- Associate a person with a new interest
- Add new links for a specific person and interest
- Create new persons
- Update name of person
- Add new interests

---

## 🔗 API Endpoints

### 👤 Persons

| HTTP Method | URL | Description |
|-------------|-----|-------------|
| GET | `/api/person` | Retrieve all persons |
| GET | `/api/person/{id}` | Retrieve detailed information about a specific person (interests + links) |
| GET | `/api/person/{id}/interests` | Retrieve all interests for a specific person |
| GET | `/api/person/{id}/links` | Retrieve all links for a specific person |
| POST | `/api/person` | Create a new person |
| PUT | `/api/person/{id}/update-name` | Update a person's name |
| DELETE | `/api/person/{id}` | Delete a person |

---

### 🎯 Interests

| HTTP Method | URL | Description |
|-------------|-----|-------------|
| POST | `/api/interest` | Create a new interest (Title + Description) |
| GET | `/api/interest` | Retrieve all interests (Title + Description) |

---

### 🔗 Links

| HTTP Method | URL | Description |
|-------------|-----|-------------|
| POST | `/api/person/{id}/interest/{interestId}/links` | Add a link for a specific person's interest |

---

## Response Bodies.

-Get detailed information about a persons interests & links by id.
```json
{
  "name": "Petter",
  "phoneNumber": "070-12002-0022",
  "interests": [
    {
      "title": "Hiking",
      "description": "Exploring mountains and nature",
      "links": [
        "https://medium.com",
        "https://trails.com"
      ]
    },
    {
      "title": "Cooking",
      "description": "Making and eating good food",
      "links": [
        "https://medium.com"
      ]
    },
    {
      "title": "Gaming",
      "description": "Playing games of all kinds",
      "links": [
        "https://trails.com",
        "https://unity.com"
      ]
    }
  ]
}
```

-Get All persons, using PersonDetailsDTO
```json
[
  {
    "id": 1,
    "name": "Fredrik",
    "phoneNumber": "070-12001-0011"
  },
  {
    "id": 2,
    "name": "Petter",
    "phoneNumber": "070-12002-0022"
  },
  {
    "id": 3,
    "name": "Person 3",
    "phoneNumber": "070-12003-0033"
  }
```
-Add new interest.
```json
{
  "id": 6,
  "title": "Chilling",
  "description": "Pick some belly button lint and watch Netflix."
}
```


