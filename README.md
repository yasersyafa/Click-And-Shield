# 📦 Lorem Ipsum Game Studio - Dev Branch

Welcome to the **dev branch** of the **Lorem Ipsum Game Studio** project. This branch is dedicated to ongoing development, and we follow strict naming conventions and programming principles to maintain code quality and consistency. Please adhere to the following guidelines when working on this branch.

## 📝 File Naming Conventions

To ensure clarity and consistency across the project, follow these rules for naming scripts:

1. **Object Script**: Name the script after the object it is associated with.
   ```
   {Object}.cs
   ```
   Example: `Player.cs`, `Enemy.cs`

2. **Multiple Words Object Script**: If the object name contains multiple words, use PascalCase for each word.
   ```
   {ObjectApa}.cs
   ```
   Example: `PlayerController.cs`, `EnemySpawner.cs`

3. **Animation Script**: If the script is specifically for animation purposes, append `Anim` to the object name.
   ```
   {ObjectAnim}.cs
   ```
   Example: `PlayerAnim.cs`, `EnemyAnim.cs`

4. **Handling Multiple Objects**: If the script manages multiple objects or processes, use `{HandlingName}{Manager}.cs` format.
   ```
   {HandlingName}{Manager}.cs
   ```
   Example: `GameManager.cs`, `AudioManager.cs`

## 🗂️ Folder Structure & Commit Guidelines

You are allowed to create new folders in the project to better organize your scripts and assets. However, **make sure to add a description when committing and pushing changes to this branch**. This description should clearly explain the purpose of the new folder.

### Example:
```
git add .
git commit -m "Added new folder 'Audio' for sound management scripts"
git push origin dev
```

## ⚙️ Programming Principles

When writing code, always remember to:

- Apply **Object-Oriented Programming (OOP)** principles to keep your code modular, reusable, and maintainable.
- Follow the **Single Responsibility Principle (SRP)** — each class should have only one responsibility or functionality.

## ⏳ Coroutine Naming Convention

When writing `IEnumerator` functions for coroutines, name them using the following format:
```
{FunctionName}{Coroutine}()
```
Example:
```csharp
IEnumerator FadeOutCoroutine() { ... }
IEnumerator MovePlayerCoroutine() { ... }
```

---

By adhering to these rules, we can maintain a clean, efficient codebase and ensure smooth collaboration across the team. 

If you have any questions or need clarifications, please reach out via the appropriate communication channels.

Happy coding! 🎮👾
