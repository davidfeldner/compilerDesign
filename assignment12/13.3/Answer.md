It does give the correct things :
Program after alpha conversion (exercise):
begin
    let
      val x1 = 2
    in
      
      let
        val x2 = 5
      in
        (x2 + x2)
      end
    end
end



(WITHOUT ALPHA -noAlpha)
begin
  
    let
      val x = 2:int
    in
      
      let
        val x = 5:int
      in
        (x:int + x:int):int
      end
    end
end
