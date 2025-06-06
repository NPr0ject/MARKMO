using System;
using System.Collections.Generic;
class HelloWorld {
  static void Main() {
    Stack<char> mysteak = new Stack<char>();
    string str = Console.ReadLine();
    bool ans = true;
    for(int i = 0; i < str.Length; i++){
        if (str[i] == '{'||str[i] == '[' || str[i] == '('){
            mysteak.Push(str[i]);
        }
        else if( mysteak.Count == 0 && (str[i] == '}'||str[i] == ']' || str[i] == ')')){
            ans = false;
            break;
        }
        else if (str[i] == '}' && mysteak.Pop() != '{' ){ 
            ans = false;
            break;
        }
        else if (str[i] == ']' && mysteak.Pop() != '[' ){
            ans = false;
            break;
        }
        else if (str[i] == ')' && mysteak.Pop() != '(' ){
            ans = false;
            break;
        }
    }
    if(mysteak.Count != 0){
        ans = false;
    }
    Console.WriteLine(ans);
  }
}
