SWAPI in GraphQL-dotnet
=======================

Just enough of SWAPI inegrated to try GraphQL-dotnet

How to run locally
------------------

After cloneing the repo

    dotnet restore

Then to run

    dotnet run


Example Query
-------------

```
{
  film (id: 3) {
    title
    episodeID
    openingCrawl
    director
    releaseDate
    producer
    characters {
      name
      height
      mass
      hairColor
      skinColor
      eyeColor
      birthYear
      homeworld
      created
      edited
    }
  }
}
```