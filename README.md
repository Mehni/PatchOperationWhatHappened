# Purpose

See what an XPath PatchOperation did. Default RimWorld gives no feedback on what happened. You can have a syntactically correct XPath doing completely the wrong thing and won't get feedback. With this tool, you can see what actually happened.

## Usage

Put the Assemblies folder with its PatchOperationWhatHappened.dll inside your mod folder.

## Example

How to get a before and after:

```xml
<Operation Class="PatchOperationSequence">
    <success>Always</success>
    <operations>
        <li Class="PatchOperationWhatHappened.Log">
            <xpath>Defs/WorldObjectDef[defName="Caravan"]</xpath>
        </li>
        <li Class="PatchOperationAdd">
            <xpath>/Defs/WorldObjectDef[defName="Caravan"]/comps</xpath>
            <value>
                <li>
                    <compClass>MyNameSpace.MyClass</compClass>
                </li>
            </value>
        </li>
        <li Class="PatchOperationWhatHappened.Log">
            <xpath>Defs/WorldObjectDef[defName="Caravan"]</xpath>
        </li>
    </operations>
</Operation>
```

### Sample Output

[HugsLib log](https://gist.github.com/HugsLibRecordKeeper/6654e57cc1b1af50a8bb462d2522e2ff#file-output_log-txt-L55-L57)

## Tips

- It's wise to PatchOperationWhatHappened.Log one level higher for a better overview.
- Patching multiple things with `Defs/ThingDef[defName="FOO" or defName="BAR"]` in one operation may result in confusing (but correct) output. The different XML nodes each get logged individually.
- Put the logged message in a good text editor with XML syntax highlighting.
