# Slot Machine Game

A 2D slot machine game developed in Unity as part of a game development assignment.

## Game Overview

The player interacts with a classic 3-reel slot machine using credits.

Each spin costs 10 credits. The three reels spin independently and stop on randomly selected symbols. Matching three symbols rewards the player according to the payout table.

### Symbols

- 7
- Cherry
- Bell
- BAR

### Payouts

| Combination | Payout |
|---|---:|
| 7 - 7 - 7 | +100 |
| Cherry × 3 | +50 |
| Bell × 3 | +30 |
| BAR × 3 | +20 |

## How to Play

1. Start with 100 credits.
2. Press the **SPIN** button.
3. Each spin costs 10 credits.
4. The lever activates and the three reels spin sequentially.
5. Match three identical symbols to receive a payout.
6. Use the **PayTable** button to view the available payouts.

## Running the WebGL Build

The WebGL build is included in:

`Build/WebGL/`

### Option 1 — Web Server

Because Unity WebGL builds cannot reliably be opened directly using `file://`, host the `Build/WebGL` folder using a local or web server.

The folder contains:

- `index.html`
- `Build/`
- `TemplateData/`

Open `index.html` through the web server to launch the game.

### Option 2 — Unity WebGL Hosting

The `Build/WebGL` folder can also be uploaded to a WebGL-compatible hosting service.

## Bonus Features

- Animated lever interaction
- Custom spin button with pressed and released states
- Sequential reel spinning
- Credit management system
- Configurable spin cost and payouts
- Paytable UI
- Win and loss feedback
- Custom sound effects
- Button, lever, reel and win audio
- Jackpot result handling
- Responsive UI layout

## Thought Process / Approach

The project was structured around separating the slot machine into small, independent systems.

### Reel System

Each reel is controlled by its own `ReelController`. The reel selects a random symbol and animates the symbol strip while maintaining the selected result.

The three reels are started sequentially to create a more natural slot machine experience.

### Economy System

`SlotMachineEconomy` manages the player's credits and spin cost.

A spin is only allowed when the player has enough credits. Credits are deducted before the spin begins and payouts are added after the result is evaluated.

### Result Evaluation

`SlotResultEvaluator` compares the final symbols from all three reels and determines whether the player has won.

The payout values are configurable through the Unity Inspector.

### UI and Interaction

The UI is separated from the core slot machine logic. The project includes a dedicated paytable controller, credit display and interactive spin button.

The lever uses separate idle and pressed sprites to provide visual feedback when the machine is activated.

### Audio

Audio is handled separately from the slot machine logic, allowing different sound effects to be assigned for button clicks, lever pulls, reel spinning, reel stopping and winning results.

## Built With

- Unity 6
- C#
- Unity 2D UI
- TextMeshPro
- WebGL

## Project Structure

```text
Assets/
├── Animations/
├── Audio/
├── Prefabs/
├── Scripts/
│   ├── Core/
│   ├── Data/
│   ├── UI/
│   └── Utilities/
├── Scenes/
└── Sprites/

Build/
└── WebGL/

Packages/
ProjectSettings/
