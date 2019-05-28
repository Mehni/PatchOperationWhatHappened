# Usage

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

## Tips

- It's wise to PatchOperationWhatHappened.Log one level higher for a better overview.
- Patching multiple things with `Defs/ThingDef[defName="FOO" or defName="BAR"]` in one operation may result in confusing (but correct) output. The different XML nodes each get logged individually.