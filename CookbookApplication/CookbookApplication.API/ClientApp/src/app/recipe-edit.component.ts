import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RecipeService } from './recipe.service';
import { Recipe } from './recipe';

@Component({
    templateUrl: './recipe-edit.component.html'
})
export class RecipeEditComponent implements OnInit {

    id: string;
    recipe: Recipe;   
    loaded: boolean = false;

    constructor(private recipeService: RecipeService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
    }

    ngOnInit() {
        if (this.id)
            this.recipeService.getRecipe(this.id)
                .subscribe((data: Recipe) => {
                    this.recipe = data;
                    if (this.recipe != null) {
                        this.loaded = true;
                    }
                });
    }

    save() {
        this.recipeService.updateRecipe(this.recipe.id, this.recipe)
                          .subscribe(data => this.router.navigateByUrl("/"));
    }
}