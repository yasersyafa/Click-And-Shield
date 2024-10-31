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

## 📜 Commit Message Guidelines

To keep commit history clean and understandable, always start your commit messages with either:
- `create feature:`
- `update feature:`

Followed by a concise description of the changes.

### Example:
```
create feature: added player movement controller
update feature: fixing enemy bug
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
scene/racing-game
scene/platformer
```

Do not work directly in `dev` or `main`. All development must be done in the corresponding minigame branch.

## 🗂️ Folder Structure

This project uses the following folder structure. **Each minigame has its own folder**, and you **must not modify others' work** to reduce the chances of conflicts:

```
📂 Assets
 ┣ 📂 Minigame1
 ┃ ┣ 📂 UI
 ┃ ┣ 📂 Characters
 ┃ ┣ 📂 Animations
 ┃ ┗ 📂 Scripts
 ┣ 📂 Minigame2
 ┃ ┣ 📂 UI
 ┃ ┣ 📂 Characters
 ┃ ┣ 📂 Animations
 ┃ ┗ 📂 Scripts
```

- **UI**: Contains all UI assets and elements used in the minigame.
- **Characters**: Contains character assets such as sprites or models.
- **Animations**: Contains animations for the minigame, whether for characters or UI.
- **Scripts**: Contains the scripts (C#) used for the minigame logic.

⚠️ **Important Rules**:
- Each person must create their **own scene** and **must not use someone else's scene**.
- **Scene naming convention**: Use the format `Minigames{number}`. Example: `Minigames1`, `Minigames2`, and so on.
- Do not modify other team members' work without permission.

## ⏳ Workflow Progress & Pull Request

- Do **not submit a pull request** unless your work is fully completed. Ensure all features or minigames are **finished** and **tested** before submitting a pull request.
- If you want to show progress, use a **video** or **screen recording** to demonstrate your progress. Do **not merge** unfinished work into the `dev` branch.
  
## 🧰 Tech Stack

The following tech stack is mandatory for this project:
- **DOTween** or **UI Tweening** for creating UI animations.
  
Ensure this library is installed and used for any UI animations you create.

---

By adhering to these rules, we can maintain a clean, efficient codebase and ensure smooth collaboration across the team. 

If you have any questions or need clarifications, please reach out via the appropriate communication channels.

Happy coding! 🎮👾
