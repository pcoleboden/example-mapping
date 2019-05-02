import { Component, Input } from '@angular/core';

@Component({
  selector: 'example-mapping',
  templateUrl: './example-mapping.component.html',
  styleUrls: ['./example-mapping.component.css']
})
export class ExampleMappingComponent {
  title: string;
  inputStory: MappingStory;

  constructor() {
    this.title = 'Hello, World!';
    this.inputStory = this.createDummyStory();
  }

  createDummyStory() {
    var s: MappingStory;
    s = {
      name: "Test story",
      questions: [
        { description: "Question 1" },
        { description: "Question 2" }
      ],
      rules: [
        {
          description: "Rule 1",
          examples: [
            { description: "Example 1 A" },
            { description: "Example 1 B" }
          ]
        },
        {
          description: "Rule 2",
          examples: [
            { description: "Example 2 A" },
            { description: "Example 2 B" }
          ]
        }
      ]
    };
    return s;
  }
}

@Component({
  selector: 'mapping-story',
  templateUrl: './mapping-story.component.html'
})
export class MappingStoryComponent {
  @Input() story: MappingStory;

  constructor() {
  }

  addQuestion() {
    this.story.questions.push({
      description: ""
    });
  }

  addRule() {
    this.story.rules.push({
      description: "",
      examples: []
    });
  }
}

@Component({
  selector: 'mapping-rule',
  templateUrl: './mapping-rule.component.html'
})
export class MappingRuleComponent {
  @Input() rule: MappingRule;

  constructor() {
  }

  addExample() {
    this.rule.examples.push({
      description: ""
    });
  }
}

@Component({
  selector: 'mapping-example',
  templateUrl: './mapping-example.component.html'
})
export class MappingExampleComponent {
  @Input() example: MappingExample;

  constructor() {
  }
}

@Component({
  selector: 'mapping-question',
  templateUrl: './mapping-question.component.html'
})
export class MappingQuestionComponent {
  @Input() question: MappingQuestion;

  constructor() {
  }
}


export class MappingStory {
  public name: string;
  public rules: MappingRule[];
  public questions: MappingQuestion[];
}

export class MappingRule {
  public description: string;
  public examples: MappingExample[];
}

export class MappingExample {
  public description: string;
}

export class MappingQuestion {
  public description: string;
}
