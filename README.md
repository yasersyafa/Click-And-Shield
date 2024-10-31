# 📦 Lorem Ipsum Game Studio - Project Click & Shield

Welcome to the **Lorem Ipsum Game Studio** game project repository! Before getting started, please read the following instructions carefully to ensure smooth collaboration and minimize conflicts during development.

## 🛠️ How to Clone the Repository

```bash
git clone https://github.com/loremipsum/project-repo.git
cd project-repo
```

## 🔀 Branching Workflow

To work on new features or minigames, always create a new branch from `dev` using the following format:

```
scene/minigame-name

```

Example:

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

If you have any further questions, feel free to discuss in GitHub Issues or contact the lead programmer.

Happy coding! 🎮👾
