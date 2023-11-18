### SocialNetworkSimulation:

This F# Social Network application simulates a basic social network system with user management, posting messages, adding friends, commenting on posts, and displaying user interactions. Users can join the network, post messages, form friendships, and engage in discussions by commenting on each other's posts.

### Features:

- **User Management:** Add users to the social network, avoiding duplicate entries.
- **Post Messages:** Users can share messages with the network.
- **Friendship:** Establish friendships between users to create social connections.
- **Comments:** Engage in discussions by commenting on posts.
- **Display:** View user posts, comments, and friends.

### Example Usage:

```fsharp
let socialNetwork = SocialNetwork()
socialNetwork.AddUser("Alice")
socialNetwork.AddUser("Bob")

socialNetwork.PostMessage("Alice", "Hello, everyone!")
socialNetwork.AddFriendship("Alice", "Bob")
socialNetwork.CommentOnPost("Bob", "Alice", "Nice post!")

socialNetwork.PrintUserFriends("Alice")
```

Feel free to contribute, report issues, or suggest improvements to enhance the functionality of this F# Social Network application.
