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
| GET | `/api/interest` | Retrieve all interests (Title + Description) |

---

### 🔗 Links

| HTTP Method | URL | Description |
|-------------|-----|-------------|
| POST | `/api/person/{id}/interest/{interestId}/links` | Add a link for a specific person's interest |

---

Swagger responses.


