## Sunstone Project
<img align="left" width="10%" src="https://github.com/praiakov/sunstone-project/blob/main/sunstone.png">

This service manages the gemstone domain.
###### ASP.NET Core 5 application with Clean Architecture based on the [uncle bob's article](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

### Architecture diagram
<img align="center" src="https://github.com/praiakov/sunstone-project/blob/main/sunstone-arch-c4.drawio.svg">

```Directory structure
├── src/                          
|   ├── Api/
|   ├── Application/
|   ├── Domain/
|   └── Infrastructure/       
└── tests/
    
```

### Endpoints
- Create gemstone
```
POST /v1/gemstone/
```
#### Example
```
{
  "name": "string",
  "carat": 0,
  "clarity": 0,
  "color": 0
}
```

###### About more: [Sunstone Wiki](https://github.com/praiakov/sunstone-project/wiki)
