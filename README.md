# Martian Robots

This C# console app solves the classic **Martian Robots** problem:
Simulate robots navigating a rectangular grid on Mars, following sequences of instructions. Robots that fall off the edge leave a "scent" to prevent future robots from doing the same from the same spot.

---

## 🧠 Thought Process

- **KISS principle** applied: simple models (`Position`, `Grid`) and `RobotService`.
- Used `enum Direction` for orientation and `switch` expressions to rotate/move.
- `Grid` maintains a `HashSet` of scented positions to avoid repeated losses.
- `RobotService.Execute` encapsulates logic cleanly to support unit tests.
- Introduced **Command Pattern** via `ICommand` interface:
  - `L` = `LeftCommand`
  - `R` = `RightCommand`
  - `F` = `ForwardCommand`
  - Easy to extend for future commands (e.g., teleport, report, wait)

---

## 🛠️ How to Run

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

### Build and Run

```bash
cd MartianRobots

dotnet build

dotnet run
```

You’ll see output for the robots in the sample input:

```
1 1 E
3 3 N LOST
2 3 S
```

---

## ✅ How to Run Tests

```bash
cd MartianRobots.Tests

dotnet test
```

This will execute the `xUnit` tests in `RobotServiceTests.cs`, validating the robot behavior against known inputs and expected outcomes.

---

## 🚀 Future Enhancements

- Accept input from a file or console.
- Add additional command types (e.g., jump, teleport).
- Simulate multiple robots in parallel.
- Add visualizer or debugging tool.

---

## 📁 Folder Structure

```
MartianRobots/
├── Models/
│   ├── Direction.cs
│   ├── Grid.cs
│   └── Position.cs
├── Commands/
│   ├── ICommand.cs
│   ├── LeftCommand.cs
│   ├── RightCommand.cs
│   └── ForwardCommand.cs
├── Services/
│   └── RobotService.cs
├── Program.cs

MartianRobots.Tests/
├── RobotServiceTests.cs
```

---
