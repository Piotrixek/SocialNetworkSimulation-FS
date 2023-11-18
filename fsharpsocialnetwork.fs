open System
open System.Collections.Generic

type Comment = {
    Username: string
    Text: string
}

type User = {
    Username: string
    Posts: string list
    Comments: Comment list
    Friends: Set<string>
}

type SocialNetwork() =
    let users = new Dictionary<string, User>()

    member this.AddUser(username: string) =
        if not (users.ContainsKey(username)) then
            let newUser = { Username = username; Posts = []; Comments = []; Friends = Set.empty }
            users.[username] <- newUser
            printfn "User '%s' has been added to the social network." username
        else
            printfn "User '%s' already exists in the social network." username

    member this.PostMessage(username: string, message: string) =
        if users.ContainsKey(username) then
            let user = users.[username]
            users.[username] <- { user with Posts = user.Posts @ [message] }
            printfn "Message posted by '%s': %s" username message
        else
            printfn "User '%s' does not exist in the social network." username

    member this.PrintUserPosts(username: string) =
        if users.ContainsKey(username) then
            let user = users.[username]
            printfn "Posts by user '%s':" username
            user.Posts |> List.iter (fun post -> printfn "- %s" post)
        else
            printfn "User '%s' does not exist in the social network." username

    member this.AddFriendship(username: string, friendName: string) =
        if users.ContainsKey(username) && users.ContainsKey(friendName) then
            let user = users.[username]
            let friend = users.[friendName]
            users.[username] <- { user with Friends = Set.add friendName user.Friends }
            users.[friendName] <- { friend with Friends = Set.add username friend.Friends }
            printfn "'%s' and '%s' are now friends." username friendName
        else
            printfn "Invalid usernames for adding friendship."

    member this.CommentOnPost(username: string, targetUsername: string, comment: string) =
        if users.ContainsKey(username) && users.ContainsKey(targetUsername) then
            let targetUser = users.[targetUsername]
            if List.length targetUser.Posts > 0 then
                users.[targetUsername] <- { targetUser with Comments = targetUser.Comments @ [{ Username = username; Text = comment }] }
                printfn "Comment posted by '%s' on '%s' post: %s" username targetUsername comment
            else
                printfn "User '%s' has no posts to comment on." targetUsername
        else
            printfn "Invalid usernames for posting a comment."

    member this.PrintUserFriends(username: string) =
        if users.ContainsKey(username) then
            let user = users.[username]
            printfn "Friends of user '%s':" username
            user.Friends |> Set.iter (fun friendName -> printfn "- %s" friendName)
        else
            printfn "User '%s' does not exist in the social network." username

// Example usage
let socialNetwork = SocialNetwork()
socialNetwork.AddUser("Alice")
socialNetwork.AddUser("Bob")
socialNetwork.AddUser("Charlie")

socialNetwork.PostMessage("Alice", "Hello, everyone!")
socialNetwork.PostMessage("Bob", "Hey there!")

socialNetwork.AddFriendship("Alice", "Bob")
socialNetwork.AddFriendship("Alice", "Charlie")

socialNetwork.CommentOnPost("Bob", "Alice", "Nice post!")
socialNetwork.CommentOnPost("Charlie", "Alice", "I agree!")

socialNetwork.PrintUserFriends("Alice")
