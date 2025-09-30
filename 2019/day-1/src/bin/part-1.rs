fn main(){
    let input = include_str!("./input1.txt");
    let output = part1(input);
    dbg!(output);
}

fn part1(input: &str) -> String{
        let mut final_num: i32 = 0;
        for line in input.lines() {
            let mut curr_num: i32 = line.parse::<i32>().expect("must be a int");
            curr_num/=3;
            curr_num-=2;
            final_num+= curr_num;
        }
    println!("{:?}", final_num );

    final_num.to_string()
}


#[cfg(test)]
mod tests{
    use super::*;

    #[test]
    fn it_works() {
        let result = part1("12
14
1969
100756");
        assert_eq!(result.to_string(), "34241".to_string());
    }
}
