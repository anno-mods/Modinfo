# modinfo.json Format

- Loading Relevant
  - [ModID](#modid)
  - [Version](#Version)
  - [ModDependencies](#moddependencies)
  - [LoadAfterIds](#loadafterids)
  - [IncompatibleIds](#incompatibleids)
- Localized Information
  - [ModName](#modname)
  - [Category](#category)
  - [Description](#description)
  - [KnownIssues](#knownissues)
- Non-Localized Information
  - [DLCDependencies](#dlcdependencies)
  - [Creator](#creator)
  - [CreatorContact](#creatorcontact)
  - [Image](#image) (deprecated)
- [Unused Formats](#unused-formats)

## Loading Relevant

### ModID

A unique identifier for your mod. You can use the same characters as for folder names (i.e. `:`, `/` are not allowed).

The `ModID` is used various features like dependencies and loading order.
If not specified the mod folder name will be used by the modloader.

Best include the creator name to avoid conflicts.

```json
"ModID": "annofan_awesome_mod"
```

### Version

`major.minor` or `major.minor.patch`.

The version is used to determine the newest mod in case of duplicates.

```json
"Version": "1.0.1"
```

### ModDependencies

A list of `ModID`s your mod depends on.

The modloader will print warnings if a dependency is missing.

Use in combination with `LoadAfterIds` if you want to depend and load after a mod.

```json
"ModDependencies": [ "another_mod", "yet_another_mod" ]
```

### LoadAfterIds

A list of `ModID`s your wants to be loaded after.

The modloader will load your mod after the mentioned mods, if they exist.
If they don't, no errors are printed.

Use `ModDependencies` if your mod requires mods to exist.

```json
"LoadAfterIds": [ "another_mod", "yet_another_mod" ]
```

### IncompatibleIds

A list of `ModID`s your mod is not compatible with.

The modloader will print errors but not disable any mods based on this information.

```json
"IncompatibleIds": [ "another_mod" ]
```

## Localized Information

Localized entries can be translated in all languages the game supports.

Mod managers should use `English` instead of empty text if the chosen language text is missing.

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

### ModName

The localized name of your mod.



```json
"ModName": {
  "English": "Beautiful Houses",
  "German": "Schöne Häuser"
}
```

### Category

The localized category of your mod.

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

### Description

A localized text description of your mod.

Use `\n` for line breaks.

```json
"Description": {
  "English": "First line\nSecond line"
}
```

Start the text with `#` if you want to use Markdown.


```json
"Description": {
  "English": "# Title\nParagraph\n## 2nd Level Title\nParagraph"
}
```

### KnownIssues

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

### DLCDependencies

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

- `Anarchist`
- Season 1: `SunkenTreasures`, `Botanica`, `ThePassage`
- Season 2: `SeatOfPower`, `BrightHarvest`, `LandOfLions`
- Season 3: `Docklands`, `Tourism`, `Highlife`
- Season 4: `SeedsOfChange`, `EmpireOfTheSkies`, `NewWorldRising`
- Cosmetic: `Christmas`, `AmusementPark`, `CityLife`, `VehicleSkins`, `PedestrianZone`, `VibrantCity`

### Creator

Your name.

```json
"Creator": "annofan"
```

### CreatorContact

A link to contact you, e.g. in case of bugs.

Best use your GitHub repository.

```json
"CreatorContact": "https://github.com/anno-mods/Modinfo"
```

### Image

You can put a base64 representation of an image for mod managers.

Deprecated. Better place a `banner.jpg` or `banner.png` in your mod folder.

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
