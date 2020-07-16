var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
let RecipeService = class RecipeService {
    constructor(http) {
        this.http = http;
        this.host = "http://localhost:62011";
        this.url = this.host + "/api/recipes";
    }
    getRecipesTree() {
        return this.http.get(this.url);
    }
    getRecipe(id) {
        return this.http.get(this.url + "/" + id);
    }
    createRecipe(recipe) {
        return this.http.post(this.url, recipe);
    }
    updateRecipe(id, recipe) {
        return this.http.put(this.url + "/" + id, recipe);
    }
};
RecipeService = __decorate([
    Injectable()
], RecipeService);
export { RecipeService };
//# sourceMappingURL=recipe.service.js.map