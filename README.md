#CommanderGQL

## .net5 with GraphQL And HotChocolate Framework

- Used: Voyager and HotChocolate packages
-  Used Bodies for Testing:
- Get the platform with children commands
```sh
query{
 platform {
    id
    name
    commands {
      id
      howTo
      commandLine
    }
  }
}
```

- Get the commands with parent platform
```sh
query{
  command {
    howTo
    commandLine
    platform {
      name
    }
  }
}
```

- Get specific command by id (Filtering)
```sh
query{
  command(where: {platformId: {eq:1}})
  {
    id
    commandLine
    howTo
    platform {
      id
      name
    }
  }
}
```

- Get Platform ordring by name
```sh
query{
  platform(order: {name:ASC}) {
    name
  }
}
```

- Adding new platform
```sh
mutation{
  addPlatform (input: {
    name: "RedHat"
  })
  {
    platform {
      id
      name
    }
  }
}
```

- Adding new command
```sh
mutation{
  addCommand(input: {
    howTo:"perform directory listing"
    commandLine:"ls"
    platformId:4
  }) {
    command {
      id
      howTo
      commandLine
      platform {
        name
      }
    }
  }
}
```

- Subscribe to add new platform and sent a notification by websocket
```sh
subscription{
  onPlatformAdded {
    id
    name
  }
}
```
