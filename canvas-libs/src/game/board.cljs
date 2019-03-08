(ns game.board)

(def fst #(first %))
(def snd #(get % 1))

(defn generate-columns
  "input: ctx, number of columns and width of a column
   returns: list of columns -> [[pointA pointB] ... ]"
  [c nCols colW]
  (reduce
    (fn [acc i]
      (let [colXPos (* colW i)]
        (conj acc [[colXPos 0] [colXPos (.-h c)]])))
    [] ; empty list of col lines
    (range nCols 0 -1)))

(defn generate-rows
  "input: ctx, number of rows and height of a row
   returns: list of rows -> [[pointA pointB] ... ]"
  [c nRows rowH]
  (reduce
    (fn [acc i]
      (let [rowYPos (* rowH i)]
        (conj acc [[0 rowYPos] [(.-w c) rowYPos]])))
    [] ; empty list of col lines
    (range nRows 0 -1)))
