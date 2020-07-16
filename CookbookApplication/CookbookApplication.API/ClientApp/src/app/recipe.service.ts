import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from './recipe';

@Injectable()
export class RecipeService {
    private host = "http://localhost:62011";
    private url = this.host + "/api/recipes";

    constructor(private http: HttpClient) {}

    getRecipesTree() {
        return this.http.get(this.url);
    }

    getRecipe(id: string) {
        return this.http.get(this.url + "/" + id);
    }

    createRecipe(recipe: Recipe) {
        return this.http.post(this.url, recipe);
    }

    updateRecipe(id: string, recipe: Recipe) {
        return this.http.put(this.url + "/" + id, recipe);
    }
}