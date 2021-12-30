import fs from "fs";

const pokemonFilePath = "wwwroot/assets/data/pokemon.json";

const pokemon = JSON.parse(fs.readFileSync(pokemonFilePath));

for (const [key, value] of Object.entries(pokemon)) {
  pokemon[key] = {
    Slug: value.slug.eng,
    HasFemaleForm: Boolean(value["gen-8"].forms.$["has_female"]),
  };
}

fs.writeFileSync(pokemonFilePath, JSON.stringify(pokemon, null, 2));

const itemsFilePath = "wwwroot/assets/data/item-map.json";

const items = JSON.parse(fs.readFileSync(itemsFilePath));

items["item_0216"] = "key-item/exp-share";

fs.writeFileSync(itemsFilePath, JSON.stringify(items, null, 2));
