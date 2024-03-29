# modinfo.json Format

The [modloader](https://github.com/jakobharder/anno1800-mod-loader#readme) integrated with GU17 uses the *loading relevant* information.
Additionally, English `Name` and `Category` are used.

Use [modinfo.json](./modinfo.json) as a template.
Optional and `null` entries can be removed.

- Loading Relevant
  - **[ModID](#modid-mandatory) (mandatory)**
  - **[Version](#version-mandatory) (mandatory)**
  - [ModDependencies](#moddependencies-optional) (optional)
  - [LoadAfterIds](#loadafterids-optional) (optional)
  - [IncompatibleIds](#incompatibleids-optional) (optional)
  - [DeprecateIds](#deprecateids-optional) (optional)
- Localized Information
  - **[ModName](#modname-mandatory) (mandatory)**
  - **[Category](#category-mandatory) (mandatory)**
  - [Description](#description-optional) (optional)
  - [KnownIssues](#knownissues-optional) (optional)
- Non-Localized Information
  - [DLCDependencies](#dlcdependencies-optional) (optional)
  - [Creator](#creator-optional) (optional)
  - [CreatorContact](#creatorcontact-optional) (optional)
  - [ModioResourceId](#ModioResourceId-optional) (optional)
  - *[Image](#image-deprecated) (deprecated)*
- Other Files
  - [Banner Image](#banner-image-optional) (optional)
- [Unused Formats](#unused-formats)

## Loading Relevant

### `ModID` (mandatory)

A unique identifier for your mod. You can use the same characters as for folder names (i.e. `:`, `/` are not allowed).

Best include the creator name to avoid conflicts.

```json
"ModID": "annofan_awesome_mod"
```

The `ModID` is used various features like dependencies and loading order.
If not specified the mod folder name will be used by the modloader - important to work with mods without `modinfo.json`.
The modloader prints an error if you have a `modinfo.json` without a `ModID`.

### `Version` (mandatory)

`major.minor` or `major.minor.patch`.

```json
"Version": "1.0.1"
```

The version is used to determine the newest mod in case of duplicates.

### `ModDependencies` (optional)

A list of `ModID`s your mod depends on.

```json
"ModDependencies": [ "another_mod", "yet_another_mod" ]
```

The modloader will print warnings if a dependency is missing.

Use in combination with `LoadAfterIds` if you want to depend and load after a mod.

### `LoadAfterIds` (optional)

A list of `ModID`s your wants to be loaded after.

Loading happens in 3 phases:

1. Load after phase: mods ordered by `LoadAfterIds`
2. Alphabetical phase: mods without `LoadAfterIds` in alphabetical order
3. Load last phase: mods marked with `*` ordered by `LoadAfterIds`

#### 1. Load After Phase

```json
"LoadAfterIds": [ "another_mod", "yet_another_mod" ]
```

The modloader will load your mod after the mentioned mods, if they exist.
If they don't, no errors are printed.
Alphabetical order will be ignored if your mod uses `LoadAfterIds` or is mentioned in another mod with `LoadAfterIds`.

Use `ModDependencies` if your mod requires mods to exist but the order care about their loading order.

#### 2. Alphabetical Phase

Loading order was previously decided by alphabetical order.
This behavior is kept as long as there are no `LoadAfterIds` listed **AND** no other mod has your mod in their `LoadAfterIds`.

DO NOT rely on this behavior.

#### 3. Load Last Phase with `*`

Mods with `*` as an ID in their `LoadAfterIds` move to the *load last phase*.

```json
"LoadAfterIds": [ "*", "another_mod" ]
```

Declaring order between mods within this is possible as long as both mods are marked with `*`.

### `IncompatibleIds` (optional)

A list of `ModID`s your mod is not compatible with.

```json
"IncompatibleIds": [ "another_mod" ]
```

The modloader will print errors but not disable any mods based on this information.

### `DeprecateIds` (optional)

A list of `ModID`s your mod is replacing.

```json
"DeprecateIds": [ "old_mod_id" ]
```

The modloader will simply exclude deprecated mods from loading.

Note: `LoadAfterIds` and `ModDependencies` are not adjusted accordingly and may lead to issues. Use with care.

## Localized Information

Localized entries can be translated in all languages the game supports.

Mod managers should use `English` instead of empty text if the chosen language text is missing.
Therefore English is mandatory for mandatory fields, other languages are optional.

The modloader uses the English texts like `[Category] ModName` for log purposes.

Example with complete list of languages:

```json
{
  "Chinese": null,
  "English": "Beautiful Houses",
  "French": null,
  "German": "Schöne Häuser",
  "Italian": null,
  "Korean": null,
  "Polish": null,
  "Russian": null,
  "Spanish": null,
  "Taiwanese": null
}
```

Note: `Chinese` is simplified and `Taiwanese` traditional.

### `ModName` (mandatory)

The localized name of your mod.
Only English is mandatory, other languages are optional.

Use only characters allowed for folder names to keep compatibility (i.e. `:`, `/` are not allowed).

```json
"ModName": {
  "English": "Beautiful Houses",
  "German": "Schöne Häuser"
}
```

### `Category` (mandatory)

The localized category of your mod.
Only English is mandatory, other languages are optional.

Use only characters allowed for folder names to keep compatibility (i.e. `:`, `/` are not allowed).

Here are some recommended category names. They are not standardized by the modloader or mod managers to group (yet?).

| Category | When to use
| - | -
| Addon | Bigger collection of a mixture of the below.
| Building | New buildings, production chains, etc.
| Gameplay | Game balancing or new game mechanics.
| Misc | Everything else.
| Ornamental | Ornament collecions.
| Shared | Shared textures, products, production chains.
| Skin | Paintbrush skins, Shift+V variants. Everything without it's own construction menu entry.
| UI | Construction menu, icon changes.

### `Description` (optional)

A localized text description of your mod.

Use `\n` for line breaks.

```json
"Description": {
  "English": "First line\nSecond line"
}
```

#### Inline Markdown

Start the text with `#` if you want to use Markdown.


```json
"Description": {
  "English": "# Title\nParagraph\n## 2nd Level Title\nParagraph"
}
```

#### External Markdown

Start the text with `file::` if you want to specify a readme file to be shown instead.


```json
"Description": {
  "English": "file::README.md"
}
```

### `KnownIssues` (optional)

A list of localized issues.

```json
"KnownIssues": [
  {
    "English": "Issue 1",
    "German": "Problem 1"
  },
  {
    "English": "Issue 2",
    "German": "Problem 2"
  }
]
```

## Non-Localized Information

### `DLCDependencies` (optional)

A list of DLC dependencies.

```json
"DLCDependencies": [
  {
    "DLC": "ThePassage",
    "Dependant": "partly"
  }
],
```

Dependant Type | Meaning
--- | ---
`required` | Mentioned DLC is required
`partly` | The mod has content relevant for that DLC, but can run without it
`atLeastOneRequired` | One of the `atLeastOneRequired` DLCs is required

#### List of DLCs

- Season 1:
  - `SunkenTreasures`, `Botanica`, `ThePassage`
  - `Anarchist`, `Christmas`
- Season 2:
  - `SeatOfPower`, `BrightHarvest`, `LandOfLions`
  - `AmusementPark`, `CityLife`
- Season 3:
  - `Docklands`, `Tourism`, `Highlife`
  - `VehicleSkins`, `PedestrianZone`, `VibrantCity`
- Season 4:
  - `SeedsOfChange`, `EmpireOfTheSkies`, `NewWorldRising`
  - `SeasonalDecorations`, `IndustryOrnaments`, `OldTown`
- Further cDLCs:
  - `DragonGarden`, `Fiesta`

### `Creator` (optional)

Your name.

```json
"Creator": "annofan"
```

### `CreatorContact` (optional)

A link to contact you, e.g. in case of bugs.

Best use your GitHub repository.

```json
"CreatorContact": "https://github.com/anno-mods/Modinfo"
```

### `ModioResourceId` (optional)

The id of your mod on mod.io

```json
"ModioResourceId": 123456
```

You can find a mods resourceID on your modio Mod page on the right panel, where it is listed as the last value:
![image](https://github.com/anno-mods/Modinfo/assets/51975164/1ac2602e-1452-4f73-9628-0a61893785eb)

### `Image` (deprecated)

You can put a base64 representation of an image for mod managers.

Deprecated. Better place a `banner.jpg` or `banner.png` in your mod folder.

## Other Files

### Banner Image (optional)

A banner image (not icon) to show in mod managers can be saved as `banner.jpg` (recommended) or `banner.png` next to your `modinfo.json`.

Prefer wide images, 16:9 or even wider banners.

## Minimal Example

```json
{
  "ModID": "kim-overhaul-ships",
  "Version": "2.1.3",
  "Category": {
    "English": "Gameplay"
  },
  "ModName": {
    "English": "Overhaul Ships"
  }
}
```

## Unused Formats

CollectionInfo

    Name                String Name of this CollectionInfo
    Version             String Version
    LastUpdate          String Date of last update in american Style: mm/dd/yyyy
    Creators            String[] All Creators
    Translators         String[] Translators
    Thanks              String[] Everyone you want to give thanks to
    ModIds              ModIdActiveTouple[] All included mods

ModIdActiveTouple

    ModId               String ModID of the included mod
    Active              bool that says whether this mod is active.
    Version             String Version of the Mod
