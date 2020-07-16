import { Component, OnInit } from '@angular/core';
import { RecipeService } from './recipe.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-tree.component.html'
})
export class RecipeTreeComponent implements OnInit {
    recipes: Recipe[];

    constructor(private recipeService: RecipeService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.recipeService.getRecipesTree().subscribe((data: Recipe[]) => this.recipes = data);
    }
}